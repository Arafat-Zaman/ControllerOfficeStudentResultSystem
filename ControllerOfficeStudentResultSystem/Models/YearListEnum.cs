using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ControllerOfficeStudentResultSystem.Models
{
	public enum YearListEnum
	{
		None,
		[DisplayName("2022")]
		_2020 = 1,
		[DisplayName("2021")]
		_2021 = 2,
		[DisplayName("2022")]
		_2022 = 3,

	}
}
