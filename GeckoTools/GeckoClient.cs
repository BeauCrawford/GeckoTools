﻿using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace GeckoTools
{
	public class GeckoClient
	{
		private static string Post(string url, string json)
		{
			byte[] byteArray = Encoding.UTF8.GetBytes(json);

			var request = (HttpWebRequest)WebRequest.Create(url);

			request.Method = "POST";
			request.ContentType = "application/x-www-form-urlencoded";
			request.ContentLength = byteArray.Length;

			using (var requestStream = request.GetRequestStream())
			{
				requestStream.Write(byteArray, 0, byteArray.Length);

				try
				{
					using (var response = request.GetResponse())
					{
						using (var responseStream = response.GetResponseStream())
						{
							using (var reader = new StreamReader(responseStream))
							{
								var postResponse = reader.ReadToEnd();


								return postResponse;
							}
						}
					}
				}
				catch (WebException ex)
				{
					using (var response = ex.Response.GetResponseStream())
					{
						using (var reader = new StreamReader(response))
						{
							var error = reader.ReadToEnd();

							throw new InvalidOperationException(error, ex);
						}
					}
				}
			}
		}

		public GeckoClient(string url, string apiKey)
		{
			Guard.NotNullOrEmpty(url, "url");
			Guard.NotNullOrEmpty(apiKey, "apiKey");

			Url = url;
			ApiKey = apiKey;
		}

		public string Url { get; private set; }

		public string ApiKey { get; private set; }

		private string GetJson(GeckoWidget widget, Formatting formatting = Formatting.None)
		{
			return JsonConvert.SerializeObject
			(
				new
				{
					api_key = ApiKey,
					data = widget.GetDataObject()
				},

				formatting
			);
		}

		public void Send(GeckoWidget widget, string key)
		{
			Guard.NotNull(widget, "widget");
			Guard.NotNullOrEmpty(key, "key");

			var errors = widget.Validate();

			if (errors.Any())
			{
			}
			else
			{
				var json = GetJson(widget, Formatting.Indented);

				Post(Url + key, json);
			}
		}
	}
}