﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigureSitecore.cs" company="Sitecore Corporation">
//   Copyright (c) Sitecore Corporation 1999-2017
// </copyright>
// <summary>
//   The SamplePlugin startup class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feature.Pricing.Engine
{
	using System.Reflection;
	using Microsoft.Extensions.DependencyInjection;
	using Sitecore.Commerce.Core;
	using Sitecore.Framework.Configuration;
	using Sitecore.Framework.Pipelines.Definitions.Extensions;
	using Sitecore.Commerce.Plugin.Pricing;

	/// <summary>
	/// The carts configure sitecore class.
	/// </summary>
	public class ConfigureSitecore : IConfigureSitecore
    {
		/// <summary>
		/// The configure services.
		/// </summary>
		/// <param name="services">
		/// The services.
		/// </param>
		public void ConfigureServices(IServiceCollection services)
		{
			var assembly = Assembly.GetExecutingAssembly();
			services.RegisterAllPipelineBlocks(assembly);

			services.Sitecore().Pipelines(config => config
				.ConfigurePipeline<IResolvePriceBookNamePipeline>(configure => configure
					.Add<Pipelines.Blocks.ResolvePriceBookNameFromCommerceShopBlock>()
				)
			);

			services.RegisterAllCommands(assembly);
		}
	}
}
