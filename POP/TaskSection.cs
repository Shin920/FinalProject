using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace POP
{
        class TaskSection : IConfigurationSectionHandler
        {
            //IConfigurationSectionHandler => config의 섹션을 사용자가 정의하고 싶을때 상속
            public object Create(object parent, object configContext, XmlNode section)
            {
                List<taskItem> myConfigObject = new List<taskItem>();
                string staskID = "", shostIP = "", shostPort = "", sremark = "";

                foreach (XmlNode childNode in section.ChildNodes)   //설비갯수만큼 5번 루프 . app.config에 <taskList>섹션안에 있는 <taskItem />이 하나의 노드인것
                {
                    foreach (XmlAttribute attrib in childNode.Attributes)
                    {
                        if (attrib.Name.Equals("taskID")) staskID = attrib.Value;
                        if (attrib.Name.Equals("hostIP")) shostIP = attrib.Value;
                        if (attrib.Name.Equals("hostPort")) shostPort = attrib.Value;
                        if (attrib.Name.Equals("remark")) sremark = attrib.Value;
                    }

                    myConfigObject.Add(new taskItem() { taskID = staskID, hostIP = shostIP, hostPort = shostPort, remark = sremark });
                }

                return myConfigObject;

            }
        }

        public class taskItem       //기계 하나하나를 taskItem이라고 생각
        {
            public string taskID { get; set; }
            public string hostIP { get; set; }
            public string hostPort { get; set; }    //config에 있는 값은 문자열이라서 port번호를 int로 해도되지만 가져오기 편하려면 string으로
            public string remark { get; set; }
        }
    }

