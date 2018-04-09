using System.Linq;
using AgileObjects.AgileMapper;
using Solution.Model.Models;

namespace Solution.CrossCutting.Mapping
{
	public class Mapping : IMapping
	{
		public Mapping()
		{
			Mapper.WhenMapping
				.From<UserModel>().To<AuthenticatedModel>()
					.Map(s => s.Source.UsersRoles.Select(x => x.Role)).To(d => d.Roles)
					.And.Map(s => s.Source.UserId).To(d => d.UserId);
		}

		public TDestination Map<TDestination>(object source)
		{
			return Mapper.Map(source).ToANew<TDestination>();
		}

		public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
		{
			return Mapper.Map(source).OnTo(destination);
		}
	}
}
