﻿namespace Baskerville.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Data.Contracts.Repository;
    using Models.DataModels;
    using Data.Repository;
    using Models.ViewModels;
    using AutoMapper;
    using Utilities;
    using Constants;
    using Models.Enums;

    public class SubscribersService : Service
    {
        private IRepository<Subscriber> subscribers;

        public SubscribersService(IDbContext context)
            : base(context)
        {
            this.subscribers = new Repository<Subscriber>(context);
        }

        public IEnumerable<SubscriberViewModel> GetActiveSubscribers()
        {
            var subscribersViewModel = this.subscribers
                .Find(s => s.IsActive && !s.IsRemoved)
                .Select(Mapper.Map<Subscriber, SubscriberViewModel>)
                .ToList();

            return subscribersViewModel;
        }

        public void RemoveSubscriber(int id)
        {
            var subscriber = this.subscribers.GetById(id);
            subscriber.IsRemoved = true;
            this.subscribers.Update(subscriber);
        }

        public void SendMessageToSubscribers(MessageViewModel model)
        {
            var subscribersBg = this.subscribers
                .Find(s => s.IsActive && !s.IsRemoved && s.PreferedLanguage == Language.BG
                ).Select(s => s.Email)
                .ToList();

            var subscribersEn = this.subscribers
                .Find(s => s.IsActive && !s.IsRemoved && s.PreferedLanguage == Language.EN)
                .Select(s => s.Email)
                .ToList();

            Emailer emailer = new Emailer(MailSettings.NoReplySettings);

            emailer.SendEmail(model.ContentBg, model.SubjectBg, false, subscribersBg);
            emailer.SendEmail(model.ContentEn, model.SubjectEn, false, subscribersEn);
        }
    }
}
