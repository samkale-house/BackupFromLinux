using System;

namespace FileIOProject.Models
{
    public class Report
    {
        public Report()
        {
            //ReportContent=new ;
        }
 public int ContentLength{get;set;}
 public Byte[] ReportContent{get;set;}

 public int ReportId{get;set;}

 public string ReportName{get;set;}
 public int StudentId{get;set;}
    }
}