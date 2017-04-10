﻿using Baskerville.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Baskerville.Services.Utilities.HtmlBuilders
{
    public class EventsBuilder : HtmlBuilder
    {
        //Representatation of event template
        //Place holders:
        //{0}: Alternative image text.
        //{1}: Image source.
        //{2}: Event name.
        //{3}: Event description.
        //{4}: Event time.
        private string eventTemplate = "<div class=\"col-sm-6 text-center\"><div class=\" bounceIn wow\"> <img alt=\"{0}\" class=\"img-responsive center-block\" height=\"600\" src=\"{1}\" width=\"800\"> </div><div class=\"fadeInUp wow\"><p class=\"mrgn20-top text-left\">{2}<br>{3}</p><p class=\"text-left\"><i class=\"fa fa-clock-o\" aria-hidden=\"true\"></i> {4}</p><p class=\"text-left mrgn30-top-btm\"><a class=\"btn btn-lg btn-outline\" href=\"https://www.facebook.com/designify.me\">RSVP Now</a> </p></div></div>";

        private IEnumerable<Event> events;
        private bool isLangBg;   


        public EventsBuilder(IEnumerable<Event> events, bool isLangBg)
        {
            this.events = events;
            this.isLangBg = isLangBg;
        }

        public override HtmlString Render()
        {
            this.GenerateEvents();
            this.Html = new HtmlString(this.Builder.ToString());

            return this.Html;
        }

        private void GenerateEvents()
        {
            foreach (var evnt in this.events)
            {
                string eventName = this.isLangBg ? evnt.NameBg : evnt.NameEn;
                string eventDescription = this.isLangBg ? evnt.DescriptionBg : evnt.DescriptionEn;
                string date = this.FormatDate(evnt.StartDate);

                this.Builder.AppendFormat(this.eventTemplate, evnt.NameEn, evnt.ImageUrl, eventName, eventDescription, date);
            }
        }

        private string FormatDate(DateTime date)
        {
            string dayOfMonth = date.ToString("dd");
            string month = this.isLangBg 
                ? LanguageTranslator.TranslateMonth(date.ToString("MMMM")) 
                : date.ToString("MMMM");
            string time = date.ToString("HH:mm");

            string formatedDate = $"{dayOfMonth} {month}, {time}";

            return formatedDate;
        }

        #region Event Template - Wide View
        //<div class="col-sm-6 text-center">
        //  <div class=" bounceIn wow"> <img alt="{0}" class="img-responsive center-block" height="600" src="{1}" width="800"> </div>
        //  <div class="fadeInUp wow">
        //      <p class="mrgn20-top text-left">{2}<br>{3}</p>
        //	    <p class="text-left"><i class="fa fa-clock-o" aria-hidden="true"></i> {4}</p>
        //      <p class="text-left mrgn30-top-btm"><a class="btn btn-lg btn-outline" href="https://www.facebook.com/designify.me">RSVP Now</a> </p>
        //  </div>
        //</div>
        #endregion
    }
}
