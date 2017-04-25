﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baskerville.Data.Contracts.Repository;
using Baskerville.Models.DataModels;
using Baskerville.Data.Repository;
using Baskerville.Models.ViewModels;
using AutoMapper;
using System.Net;

namespace Baskerville.Services
{
    public class NewsService : Service
    {
        private IRepository<News> news;

        public NewsService(IDbContext context)
            : base(context)
        {
            this.news = new Repository<News>(context);
        }

        public IEnumerable<NewsViewModel> GetAllNews()
        {
            var model = this.news
                .Find(n => !n.IsRemoved)
                .Select(Mapper.Map<News, NewsViewModel>)
                .ToList();

            return model;
        }

        public NewsViewModel GetNewsById(int id)
        {
            var newsFromDb = this.news.GetById(id);
            if (newsFromDb == null)
                return null;

            var model = Mapper.Map<News, NewsViewModel>(newsFromDb);
            return model;
        }

        public HttpStatusCode DeleteNewsById(int id)
        {
            var _news = this.news.GetById(id);

            if (_news == null)
                return HttpStatusCode.NotFound;

            _news.IsRemoved = true;
            this.news.Update(_news);

            return HttpStatusCode.OK;
        }

        public void UpdateNews(NewsViewModel model)
        {
            var newsFromDb = this.news.GetById(model.Id);

            Mapper.Map(model, newsFromDb);
            this.news.Update(newsFromDb);
        }

        public void CreateNews(NewsViewModel model)
        {
            News _news = Mapper.Map<NewsViewModel, News>(model);
            this.news.Insert(_news);
        }
    }
}