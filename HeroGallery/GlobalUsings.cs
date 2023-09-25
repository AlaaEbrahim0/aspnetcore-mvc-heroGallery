﻿global using System.IO;
global using System;
global using System.Linq;
global using System.Security.Claims;
global using System.Threading.Tasks;
global using System.Collections.Generic;
global using System.Net;
global using System.Net.Mail;
global using System.ComponentModel.DataAnnotations;
global using System.ComponentModel.DataAnnotations.Schema;
global using HeroGallery.Extensions;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.AspNetCore.Identity.UI.Services;
global using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Diagnostics;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.Extensions.Logging;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.AspNetCore.Hosting;
global using Microsoft.Extensions.Configuration;
global using Microsoft.AspNetCore.Authentication;
global using Microsoft.Extensions.Hosting;
global using Microsoft.AspNetCore.Http;

global using HeroGallery.Models;
global using HeroGallery.ViewModel;
global using HeroGallery.Repositores;
global using HeroGallery.Utilites;
global using HeroGallery.Models.Lookups;

global using Newtonsoft.Json;
global using Microsoft.AspNetCore.Builder;
global using Microsoft.AspNetCore.Mvc.Authorization;
global using Microsoft.Extensions.DependencyInjection;