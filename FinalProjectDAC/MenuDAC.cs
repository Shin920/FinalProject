using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectDAC
{
    public class MenuDAC : IDisposable
    {
        SqlConnection conn;
        public MenuDAC()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["team2"].ConnectionString);
            conn.Open();
        }
        public void Dispose()
        {
            conn.Close();
        }

        public DataTable GetMenu()      //메뉴 목록 정렬해서 가져오기
        {
            string sql = @"select Seq, Menu_Name, Screen_Code, Menu_level, Parent_Screen_Code, Sort_index from MenuTree_Master order by Parent_Screen_Code, Sort_index";

            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
                da.Fill(dt);
            }
            return dt;
        }

        public DataTable GetMenuAuthList()
        {

            string sql = @"select menu_auth_id, Screen_Code, ma.UserGroup_Code, UserGroup_Name
from Menu_Auth ma inner join UserGroup_Master gm on ma.UserGroup_Code = gm.UserGroup_Code order by Screen_Code, ma.UserGroup_Code";     //일단 메뉴id로 정렬했다가 같은 애들은 authid로 정렬

            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
                da.Fill(dt);
            }
            return dt;
        }

        public DataTable GetAuthList()
        {

            string sql = @"select UserGroup_Code, UserGroup_Name from UserGroup_Master order by UserGroup_Code";

            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
                da.Fill(dt);
            }
            return dt;
        }

        public bool SaveMenuAuth(int menu_id, List<string> authList)
        {
            string authStr = string.Join(",", authList);    //"1,2,3" 이런식
            string sql = @"
delete from Menu_Auth where Screen_Code = @Screen_Code;
                            insert into Menu_Auth (Screen_Code, UserGroup_Code) 
                            select @Screen_Code, item from dbo.SplitString(@auths, ',')"; //전에 만들었던 저장함수인 SplitString를 사용해서 문자열을 구분
            //하나의 쿼리문으로 두개의 작업을 실행 . ;으로 구분지어주면 된다. (insert 할때 기존에 있던 애들은 삭제하고 새로 리스트에 있는 애들을 넣어야 같은게 누적이 안된다)

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Screen_Code", menu_id);
                cmd.Parameters.AddWithValue("@auths", authStr);
                
                int iCnt = cmd.ExecuteNonQuery();
               

                return (iCnt > 0);
            }
        }

        public DataTable GetUserMenuList(string groupCode)
        {
            string sql = @"select Screen_Code, Menu_Name, Menu_level, Parent_Screen_Code, Program_Name, Sort_index
from MenuTree_Master
where Screen_Code in (select Screen_Code				-- 서브쿼리는 행이 여러개일때는 = 이 아니라 in으로 해야함
from Menu_Auth ma inner join UserGroup_Master u on ma.UserGroup_Code = u.UserGroup_Code
where ma.UserGroup_Code = @UserGroup_Code)
union
select distinct P.Screen_Code,  P.Menu_Name,  P.Menu_level,  P.Parent_Screen_Code,  P.Program_Name,  P.Sort_index	--위에 자식메뉴들의 부모메뉴를 찾는것
from MenuTree_Master P inner join MenuTree_Master C on P.Screen_Code = C.Parent_Screen_Code		--재귀쿼리(본인을 조인) - 자신의 메뉴아이디와 부모메뉴id가 같은걸 찾아서 하나로 만드려고
where C.Screen_Code in (select Screen_Code			-- 서브쿼리는 행이 여러개일때는 = 이 아니라 in으로 해야함
from Menu_Auth ma inner join UserGroup_Master u on ma.UserGroup_Code = u.UserGroup_Code
where ma.UserGroup_Code = @UserGroup_Code)";

            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
                da.SelectCommand.Parameters.AddWithValue("@UserGroup_Code", groupCode);
                da.Fill(dt);
            }
            return dt;
        }

        public bool InsertBookMark(string userId, string formName)     //해당 폼을 즐겨찾기 리스트에 추가
        {
            using(SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = @"insert into Favorite_Master (User_ID, Screen_Code, Ins_Date) 
values(@User_ID, (select Screen_Code from MenuTree_Master where Program_Name = @Program_Name), getdate())";

                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@User_ID", userId);
                cmd.Parameters.AddWithValue("@Program_Name", formName);

                return cmd.ExecuteNonQuery() > 0;

                 
            }
        }
        public bool DeleteBookMark(string userId, string programName)     //해당 폼을 즐겨찾기 리스트에서 삭제
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = @"delete from Favorite_Master where User_ID = @User_ID and Screen_Code = (select Screen_Code from MenuTree_Master where Program_Name = @Program_Name)";

                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@User_ID", userId);
                cmd.Parameters.AddWithValue("@Program_Name", programName);

                return cmd.ExecuteNonQuery() > 0;


            }
        }

        public DataTable GetBookMarkList(string userID)     //해당 사용자의 즐겨찾기 목록
        {

            string sql = @"select Menu_Name, Program_Name
from Favorite_Master fm inner join MenuTree_Master mm on fm.Screen_Code = mm.Screen_Code
where User_ID = @User_ID";

            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
                da.SelectCommand.Parameters.AddWithValue("@User_ID", userID);

                da.Fill(dt);
            }
            return dt;
        }

        public string GetUserNote(string userID)        //사용자의 메모내용을 불러온다
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = @"select Descriptions from UserNote where User_ID = @User_ID";

                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@User_ID", userID);

                SqlDataReader reader = cmd.ExecuteReader();
                string str = null;
                while (reader.Read())
                {
                    str = reader["Descriptions"].ToString();
                }

                return str;
            }
        }

        public void InsertNewNote(string userID, string note)        //메모를 처음 등록하는지 원래 있었는지 확인후 insert하거나 update
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SP_Note";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@P_User_ID", userID);
                cmd.Parameters.AddWithValue("@P_Descriptions", note);

                 cmd.ExecuteNonQuery();
            }
        }

       

        public DataTable GetUserInfo(string userID)     //사용자 이름,그룹
        {

            string sql = @"select User_Name, UserGroup_Name , gm.UserGroup_Code
from User_Master um inner join UserGroup_Mapping gm on um.User_ID = gm.User_ID
					inner join UserGroup_Master gs on gm.UserGroup_Code = gs.UserGroup_Code
					where um.User_ID = @User_ID";

            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
                da.SelectCommand.Parameters.AddWithValue("@User_ID", userID);

                da.Fill(dt);
            }
            return dt;
        }

    }
}
