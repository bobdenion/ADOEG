using System;
using System.Data.SqlClient;
using System.Data;


namespace ADOEG
{
    class Program
    {
        public static SqlConnection con;
        public static SqlCommand cmd;

        static void main(string[] args)
        {
            //InsertData();
            //UpdateData();
            //DeleteData();
            DisconSelect();
            SelectData();
        }

        private static void SelectData()
        {
            con = getCon();
            cmd = new SqlCommand("select * from Employee");
            cmd.Connection = con;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    Console.Write(dr[i]);
                }
                Console.WriteLine();
            }

        }

        private static void DisconSelect()
        {
            con = getCon();
            cmd = new SqlCommand("select * from employee;select * from departments");
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            foreach(DataRow dr in dt.Rows)
            {
                foreach(var item in dr.ItemArray)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }



        }
        private static SqlConnection getCon()
        {
            con = new SqlConnection("Data Source=CIWE-MTP-SQL1;Initial Catalog=BOBD;Integrated Security=true");
            con.Open();
            return con;
        }

        private static void InsertData()
        {
            con = getCon();
            Console.WriteLine("Enter eid,empname,salary,date,type boolean,deptid,mgr");
            int eid = Convert.ToInt32(Console.ReadLine());
            string Empname = Console.ReadLine();
            float sal = float.Parse(Console.ReadLine());
            DateTime doj = Convert.ToDateTime(Console.ReadLine());
            bool type = Convert.ToBoolean(Console.ReadLine());
            int deptid = Convert.ToInt32(Console.ReadLine());
            int mgr = Convert.ToInt32(Console.ReadLine());
            cmd = new SqlCommand("insert into employee values(@Empid,@Empname,@Salary,@Doj,@Emptype,@deptid,@manager)");
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@Empid", eid);
            cmd.Parameters.AddWithValue("@Empname", Empname);
            cmd.Parameters.AddWithValue("@Salary", sal);
            cmd.Parameters.AddWithValue("@Doj", doj);
            cmd.Parameters.AddWithValue("@Emptype", type);
            cmd.Parameters.AddWithValue("@deptid", deptid);
            cmd.Parameters.AddWithValue("@manager", mgr);
            cmd.ExecuteNonQuery();


        }

        private static void UpdateData()
        {
            try
            {
                con = getCon();
                Console.WriteLine("Enter Empid,Salary,Deptid");
                int eid = Convert.ToInt32(Console.ReadLine());
                float sal = float.Parse(Console.ReadLine());
                int did = Convert.ToInt32(Console.ReadLine());
                string Empname = Console.ReadLine();
                // cmd = new SqlCommand("update employee set EmpName = @EmpName where EmpId = @EmpId");
                cmd = new SqlCommand("update employee set salary=@salary,deptid=@deptid where EmpId = @EmpId");
                cmd.Connection = con;
                //cmd.Parameters.AddWithValue("@EmpId", eid);
                //cmd.Parameters.AddWithValue("@EmpName", Empname);
                cmd.Parameters.AddWithValue("@EmpId", eid);
                cmd.Parameters.AddWithValue("@salary", sal);
                cmd.Parameters.AddWithValue("@deptid", did);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private static void DeleteData()
        {
            con = getCon();
            Console.WriteLine("Enter Empid");
            int eid = Convert.ToInt32(Console.ReadLine());
            cmd = new SqlCommand("delete from employee where EmpId = @EmpId");
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@EmpId", eid);
            cmd.ExecuteNonQuery();
        }

    }
}
