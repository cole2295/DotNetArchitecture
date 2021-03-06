﻿using Solution.CrossCutting.Values;
using Solution.Model.Models;

namespace Solution.Application.Applications
{
	public interface IUserApplication : IBaseApplication
	{
		PagedList<UserModel> List(PagedListParameters parameters);

		UserModel Select(long userId);
	}
}
