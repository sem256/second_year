using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Library_4;
using System.Data.SqlClient;
using System.Data;

namespace F4_WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public double F4_WCF(double x)
        {
            return KI3_Class_4.F4(x, 2);
        }

        public System.Data.DataTable GetAllWorkers()
        {
            System.Data.DataTable d = new System.Data.DataTable();

            string connectionString = "Data Source=sem\\sqlexpress;Initial Catalog=hospital for Infectious Diseases;Integrated Security=True";
            string command = "select * from Hospital_Patients";

            DataSet data = new DataSet();
            SqlDataAdapter add = new SqlDataAdapter(command, connectionString);
            add.Fill(data);

            return data.Tables[0];
        }

        public System.Data.DataTable GetWorkerByID(int ID)
        {
            System.Data.DataTable d = new System.Data.DataTable();

            string connectionString = "Data Source=sem\\sqlexpress;Initial Catalog=hospital for Infectious Diseases;Integrated Security=True";
            string command = "select * from Hospital_Patients where id = " + ID;

            DataSet data = new DataSet();
            SqlDataAdapter add = new SqlDataAdapter(command, connectionString);
            add.Fill(data);

            return data.Tables[0];
        }
    }
}
