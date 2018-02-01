using System;
using System.ComponentModel.DataAnnotations;
using App.Models;
using App.Common;

namespace App.Models.MIS
{
    public class MIS_Article_CategoryModel
    {
        [MaxWordsExpression(100)]
        [Display(Name = "Id")]
        public string Id { get; set; }

        [Display(Name = "ChannelId")]
        public int? ChannelId { get; set; }

        [MaxWordsExpression(200)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [MaxWordsExpression(100)]
        [Display(Name = "ParentId")]
        public string ParentId { get; set; }

        [Display(Name = "Sort")]
        public int Sort { get; set; }

        [MaxWordsExpression(510)]
        [Display(Name = "ImgUrl")]
        public string ImgUrl { get; set; }

        [MaxWordsExpression(4000)]
        [Display(Name = "BodyContent")]
        public string BodyContent { get; set; }

        [Display(Name = "CreateTime")]
        public DateTime? CreateTime { get; set; }

        [Display(Name = "Enable")]
        public bool Enable { get; set; }

    }
}
