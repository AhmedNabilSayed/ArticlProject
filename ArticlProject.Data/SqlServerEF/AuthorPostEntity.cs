﻿using ArticlProject.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticlProject.Data.SqlServerEF
{
    public   class AuthorPostEntity : IDataHelper<AuthorPost>
    {
        private DBContext db;
        private AuthorPost _table;
        public AuthorPostEntity()
        {
            db = new DBContext();
        }
        public int Add(AuthorPost table)
        {
            if(db.Database.CanConnect())
            {
                db.AuthorPosts.Add(table);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int Delete(int Id)
        {
            if (db.Database.CanConnect())
            {
                _table = Find(Id);
                db.AuthorPosts.Remove(_table);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int Edit(int Id, AuthorPost table)
        {
            db = new DBContext();
            if (db.Database.CanConnect())
            {
                db.AuthorPosts.Update(table);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public AuthorPost Find(int Id)
        {
            if(db.Database.CanConnect())
            {
                return db.AuthorPosts.Where(x=>x.Id== Id).First();
            }
            else
            {
                return null;
            }
        }

        public List<AuthorPost> GetAllData()
        {
            if (db.Database.CanConnect())
            {
                return db.AuthorPosts.ToList();
            }
            else
            {
                return null;
            }
        }

        public List<AuthorPost> GetDataByUser(string UserId)
        {
            if (db.Database.CanConnect())
            {
                return db.AuthorPosts.Where(x=> x.UserId==UserId).ToList();
            }
            else
            {
                return null;
            }
        }

        public List<AuthorPost> Search(string SearchItem)
        {
            if(db.Database.CanConnect())
            {
                return db.AuthorPosts.Where(x =>
                x.FullName.Contains(SearchItem)
                ||x.UserId.Contains(SearchItem)
                ||x.UserName.Contains(SearchItem)
                ||x.PostTitle.Contains(SearchItem)
                ||x.PostDescription.Contains(SearchItem)
                ||x.PostImageUrl.Contains(SearchItem)
                ||x.AuthorId.ToString().Contains(SearchItem)
                ||x.CategoryId.ToString().Contains(SearchItem)
                ||x.PostCategory.Contains(SearchItem)
                ||x.AddedDate.ToString().Contains(SearchItem)
                || x.Id.ToString().Contains(SearchItem))
                .ToList();
            }
            else
            {
                return null;
            }
        }
    }
}
