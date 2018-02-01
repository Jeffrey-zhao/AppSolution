using System;
using System.ComponentModel.DataAnnotations;
using App.Models;
using App.Common;

namespace App.Models.MIS
{
    public class MIS_ArticleModel
    {
        [MaxWordsExpression(100)]
        [Display(Name = "Id")]
        public string Id { get; set; }

        [Display(Name = "ChannelId")]
        public int ChannelId { get; set; }

        [MaxWordsExpression(100)]
        [Display(Name = "CategoryId")]
        public string CategoryId { get; set; }

        [MaxWordsExpression(200)]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [MaxWordsExpression(510)]
        [Display(Name = "ImgUrl")]
        public string ImgUrl { get; set; }

        [MaxWordsExpression(4000)]
        [Display(Name = "BodyContent")]
        public string BodyContent { get; set; }

        [Display(Name = "Sort")]
        public int Sort { get; set; }

        [Display(Name = "Click")]
        public int Click { get; set; }

        [Display(Name = "CheckFlag")]
        public int CheckFlag { get; set; }

        [MaxWordsExpression(100)]
        [Display(Name = "Checker")]
        public string Checker { get; set; }

        [Display(Name = "CheckDateTime")]
        public DateTime? CheckDateTime { get; set; }

        [MaxWordsExpression(100)]
        [Display(Name = "Creater")]
        public string Creater { get; set; }

        [Display(Name = "CreateTime")]
        public DateTime? CreateTime { get; set; }

    }
}
