using System;
using System.ComponentModel.DataAnnotations;
using App.Models;
namespace App.Models.Sys
{
    public class SysUserModel
    {
        [Display(Name = "Id")]
        public string Id { get; set; }

        [Display(Name = "用户名")]
        public string UserName { get; set; }
        [Display(Name = "密码")]
        public string Password { get; set; }

        [Display(Name = "真实姓名")]
        public string TrueName { get; set; }

        [Display(Name = "卡号")]
        public string Card { get; set; }

        [Display(Name = "身份证")]
        public string MobileNumber { get; set; }

        [Display(Name = "电话号码")]
        public string PhoneNumber { get; set; }

        [Display(Name = "QQ")]
        public string QQ { get; set; }

        [Display(Name = "Email")]
        public string EmailAddress { get; set; }

        [Display(Name = "其他联系方式")]
        public string OtherContact { get; set; }
        [Display(Name = "省份")]
        public string Province { get; set; }

        [Display(Name = "城市")]
        public string City { get; set; }

        [Display(Name = "村镇")]
        public string Village { get; set; }

        [Display(Name = "地址")]
        public string Address { get; set; }

        [Display(Name = "是否启用")]
        public bool State { get; set; }

        [Display(Name = "创建时间")]
        public DateTime? CreateTime { get; set; }

        [Display(Name = "创建人")]
        public string CreatePerson { get; set; }

        [Display(Name = "性别")]
        public string Sex { get; set; }

        [Display(Name = "生日")]
        public DateTime? Birthday { get; set; }

        [Display(Name = "加入时间")]
        public DateTime? JoinDate { get; set; }

        [Display(Name = "婚姻")]
        public string Marital { get; set; }

        [Display(Name = "党派")]
        public string Political { get; set; }

        [Display(Name = "民族")]
        public string Nationality { get; set; }

        [Display(Name = "籍贯")]
        public string Native { get; set; }

        [Display(Name = "毕业学校")]
        public string School { get; set; }

        [Display(Name = "就读专业")]
        public string Professional { get; set; }

        [Display(Name = "学历")]
        public string Degree { get; set; }

        [Display(Name = "部门")]
        public string DepId { get; set; }

        [Display(Name = "职位")]
        public string PosId { get; set; }

        [Display(Name = "个人简介")]
        public string Expertise { get; set; }

        [Display(Name = "在职状况")]
        public string JobState { get; set; }

        [Display(Name = "照片")]
        public string Photo { get; set; }

        [Display(Name = "附件")]
        public string Attach { get; set; }

    }
}
