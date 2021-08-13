﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using WBBvNext.School.Model;


namespace WBBvNext.ViewModel._Student.StudentVMs
{
    public partial class StudentVM : BaseCRUDVM<Student>
    {
        [Display(Name = "专业")]
        public List<string> SelectedStudentMajorIDs { get; set; }

        public StudentVM()
        {
            SetInclude(x => x.StudentMajor);
        }

        protected override void InitVM()
        {
            SelectedStudentMajorIDs = Entity.StudentMajor?.Select(x => x.MajorId.ToString()).ToList();
        }

        public override void DoAdd()
        {
            Entity.StudentMajor = new List<StudentMajor>();
            if (SelectedStudentMajorIDs != null)
            {
                foreach (var id in SelectedStudentMajorIDs)
                {
                     StudentMajor middle = new StudentMajor();
                    middle.SetPropertyValue("MajorId", id);
                    Entity.StudentMajor.Add(middle);
                }
            }
           
            base.DoAdd();
        }

        public override void DoEdit(bool updateAllFields = false)
        {
            Entity.StudentMajor = new List<StudentMajor>();
            if(SelectedStudentMajorIDs != null )
            {
                 foreach (var item in SelectedStudentMajorIDs)
                {
                    StudentMajor middle = new StudentMajor();
                    middle.SetPropertyValue("MajorId", item);
                    Entity.StudentMajor.Add(middle);
                }
            }

            base.DoEdit(updateAllFields);
        }

        public override void DoDelete()
        {
            base.DoDelete();
        }
    }
}
