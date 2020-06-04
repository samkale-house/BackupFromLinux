using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
//using System;
using System.IO;
using System.Data.SqlClient;
using System.Data;

namespace MonitorLocation
{
    class Program
    {
        static void Main(string[] args)
        {    
           RunAlways();           
        }
        
       // [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public static void RunAlways()
        {
            try{
             using (FileSystemWatcher watcher = new FileSystemWatcher())
                {
            String DirectiveLocation=@"/home/mrmlabs/Sam_Workspace/Monitoring_Dir";
         
         watcher.Path=DirectiveLocation;
         //notify if these actions happened
          watcher.NotifyFilter = NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.FileName
                                 | NotifyFilters.DirectoryName;
         watcher.Filter="*.txt*";//look for only text files
         
         //add calleing method for filrcreation event

            // Add event handlers.
            //watcher.Changed += OnChanged;
            watcher.Created += OnChanged;
            //watcher.Deleted += OnChanged;
            //watcher.Renamed += OnRenamed;

         watcher.EnableRaisingEvents=true;//begin watching
         Console.WriteLine("Enter q to stop monitoring");
         while(Console.Read()!='q');
        }
              }
             catch(Exception e)
             {Console.WriteLine(e.Message);}
        }
        // Define the event handlers.
    private static void OnChanged(object source, FileSystemEventArgs e) 
    {    // Specify what is done when a file is changed, created, or deleted.
        Console.WriteLine($"File: {e.FullPath} {e.ChangeType}");

        //on file creation read that file and create new pdf.store that pdf in database.
        Console.WriteLine(CreateReport(e.FullPath)+" report generated."); 
                
    }

    private static void OnRenamed(object source, RenamedEventArgs e)
      {  // Specify what is done when a file is renamed.
        Console.WriteLine($"File: {e.OldFullPath} renamed to {e.FullPath}");
      }

      private static string CreateReport(string path)
      {
          //open file
          //generate pdf
          //copy content of file o pdf
          //close pdf and file
          //return pdffilepath
          FileStream fs =File.Open(path,FileMode.Open,FileAccess.Read);
   
       
            string FileName=System.IO.Path.GetFileNameWithoutExtension(path);
            string pdfname=FileName+"_Report_"+DateTime.Now.Date.TimeOfDay+".pdf";
          Document document=new Document();
          Page page=new Page();
          document.Pages.Add(page);
          string labelText = "start";
          using (StreamReader streamReader=new StreamReader(fs))
          {
             labelText=streamReader.ReadToEnd();
          }    
            Label label = new Label(labelText, 0, 0, 504, 100, Font.Helvetica, 18, TextAlign.Center);
            page.Elements.Add(label);
            
            
            document.Draw(pdfname);
          FileStream fspdf =File.Open(pdfname,FileMode.Open,FileAccess.Read);

         BinaryReader br = new BinaryReader(fspdf);
         Byte[] bytes = br.ReadBytes((Int32)fspdf.Length);
         int contentLength=(Int32)fspdf.Length;
         br.Close();
         //insert the file into database
         int reportid=642;
          int studentid=345;
          string strQuery = "insert into UserReports(ReportId,ReportName, ContentLength, ReportContent) values (@ReportId,@ReportName, @ContentLength, @ReportContent)";

SqlCommand cmd = new SqlCommand(strQuery);
cmd.Parameters.Add("@ReportId", SqlDbType.Int).Value = reportid;
cmd.Parameters.Add("@ReportName", SqlDbType.VarChar).Value = pdfname;

cmd.Parameters.Add("@ContentLength", SqlDbType.VarChar).Value =contentLength;

cmd.Parameters.Add("@ReportContent", SqlDbType.Binary).Value = bytes;
cmd.Parameters.Add("@StudentId", SqlDbType.Int).Value = studentid;

if(InsertUpdateData(cmd))
Console.Write(pdfname+" report saved to db");
else
Console.Write("something went wrong");

          return "pdfname";
       }

       private static Boolean InsertUpdateData(SqlCommand cmd)

{

    String strConnString = "Data Source=localhost;database=FileIOReportDB;Uid=SA;Password=SAadmin123";
    

    SqlConnection con = new SqlConnection(strConnString);

    cmd.CommandType = CommandType.Text;

    cmd.Connection = con;

    try

    {

        con.Open();

        cmd.ExecuteNonQuery();

        return true;

    }

    catch (Exception ex)

    {

        Console.Write(ex.Message);

        return false;

    }

    finally

    {

        con.Close();

        con.Dispose();

    }

}
/*private void download (DataTable dt)

{

    Byte[] bytes = (Byte[])dt.Rows[0]["Data"];

    Response.Buffer = true;

    Response.Charset = "";

    Response.Cache.SetCacheability(HttpCacheability.NoCache);

    Response.ContentType = dt.Rows[0]["ContentType"].ToString();

    Response.AddHeader("content-disposition", "attachment;filename="

    + dt.Rows[0]["Name"].ToString());

    Response.BinaryWrite(bytes);

    Response.Flush();

    Response.End();

}*/
     
      }
        
    }

