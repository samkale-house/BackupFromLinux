using System;
using System.Collections.Generic;

namespace Blog.Models
{
    public class BlogViewModel{
        public BlogViewModel(){
            Mypost=new Post();
            posts=new List<Post>();
        }
        public Post Mypost{get;set;} 
        public List<Post> posts{get;set;}
    }
}