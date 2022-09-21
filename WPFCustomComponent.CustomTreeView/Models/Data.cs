using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCustomComponent.CustomTreeView.Models
{
    public class CompanyData
    {
        public string Name { get; set; }
        public List<DempartmentData> DempartmentDatas { get; set; }
    }

    //部门数据
    public class DempartmentData
    {
        public string Name { get; set; }
        public List<EmployeeData> EmployeeDatas { get; set; }
    }

    //员工
    public class EmployeeData
    {
        public string Name { get; set; }
    }
}
