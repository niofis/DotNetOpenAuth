﻿//-----------------------------------------------------------------------
// <copyright file="ServiceProviderDescriptionTests.cs" company="Andrew Arnott">
//     Copyright (c) Andrew Arnott. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace DotNetOAuth.Test {
	using System;
	using DotNetOAuth.Messaging;
	using Microsoft.VisualStudio.TestTools.UnitTesting;

	/// <summary>
	/// Tests for the <see cref="ServiceProviderEndpoints"/> class.
	/// </summary>
	[TestClass]
	public class ServiceProviderDescriptionTests : TestBase {
		/// <summary>
		/// A test for UserAuthorizationUri
		/// </summary>
		[TestMethod]
		public void UserAuthorizationUriTest() {
			ServiceProviderDescription target = new ServiceProviderDescription();
			MessageReceivingEndpoint expected = new MessageReceivingEndpoint("http://localhost/authorization", HttpDeliveryMethod.GetRequest);
			MessageReceivingEndpoint actual;
			target.UserAuthorizationEndpoint = expected;
			actual = target.UserAuthorizationEndpoint;
			Assert.AreEqual(expected, actual);

			target.UserAuthorizationEndpoint = null;
			Assert.IsNull(target.UserAuthorizationEndpoint);
		}

		/// <summary>
		/// A test for RequestTokenUri
		/// </summary>
		[TestMethod]
		public void RequestTokenUriTest() {
			var target = new ServiceProviderDescription();
			MessageReceivingEndpoint expected = new MessageReceivingEndpoint("http://localhost/requesttoken", HttpDeliveryMethod.GetRequest);
			MessageReceivingEndpoint actual;
			target.RequestTokenEndpoint = expected;
			actual = target.RequestTokenEndpoint;
			Assert.AreEqual(expected, actual);

			target.RequestTokenEndpoint = null;
			Assert.IsNull(target.RequestTokenEndpoint);
		}

		/// <summary>
		/// Verifies that oauth parameters are not allowed in <see cref="ServiceProvider.RequestTokenUri"/>,
		/// per section OAuth 1.0 section 4.1.
		/// </summary>
		[TestMethod, ExpectedException(typeof(ArgumentException))]
		public void RequestTokenUriWithOAuthParametersTest() {
			var target = new ServiceProviderDescription();
			target.RequestTokenEndpoint = new MessageReceivingEndpoint("http://localhost/requesttoken?oauth_token=something", HttpDeliveryMethod.GetRequest);
		}

		/// <summary>
		/// A test for AccessTokenUri
		/// </summary>
		[TestMethod]
		public void AccessTokenUriTest() {
			var target = new ServiceProviderDescription();
			MessageReceivingEndpoint expected = new MessageReceivingEndpoint("http://localhost/accesstoken", HttpDeliveryMethod.GetRequest);
			MessageReceivingEndpoint actual;
			target.AccessTokenEndpoint = expected;
			actual = target.AccessTokenEndpoint;
			Assert.AreEqual(expected, actual);

			target.AccessTokenEndpoint = null;
			Assert.IsNull(target.AccessTokenEndpoint);
		}
	}
}