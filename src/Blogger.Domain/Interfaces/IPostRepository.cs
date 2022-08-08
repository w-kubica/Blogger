﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blogger.Domain.Entities;

namespace Blogger.Domain.Interfaces
{
    public  interface IPostRepository
    {
        IEnumerable<Post> GetAll();
        Post GetById(int id);
        Post Add (Post post);
        void Update (Post post);
        void Delete (Post post);
    }
}
