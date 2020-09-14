﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OneMFS.SharedResources;
using System.Text;


namespace ClientReport.ReportApiServer
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			JwtModel model = GetJwtSettings();

			services.AddAuthentication(options => {
				options.DefaultAuthenticateScheme = "JwtBearer";
				options.DefaultChallengeScheme = "JwtBearer";
			})
			.AddJwtBearer("JwtBearer", jwtBearerOptions => {
				jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(model.Key)),

					ValidateIssuer = false,
					ValidIssuer = model.Issuer,

					ValidateAudience = true,
					ValidAudience = model.Audience,

					ValidateLifetime = true,
					ClockSkew = TimeSpan.FromMinutes(model.MinutesToExpiration)
				};
			});
			services.AddCors();
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			app.UseAuthentication();
			app.UseMvc();
		}
		public JwtModel GetJwtSettings()
		{
			JwtSettings settings = new JwtSettings();
			return settings.Initiate();
		}
	}
}
