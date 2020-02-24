/*
 * This file is automatically generated; any changes will be lost. 
 */

#nullable enable

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Beef.Entities;
using Beef.WebApi;
using Newtonsoft.Json.Linq;
using Beef.Demo.Common.Entities;
using RefDataNamespace = Beef.Demo.Common.Entities;

namespace Beef.Demo.Common.Agents.ServiceAgents
{
    /// <summary>
    /// Defines the Gender Web API service agent.
    /// </summary>
    public partial interface IGenderServiceAgent
    {
        /// <summary>
        /// Gets the <see cref="Gender"/> object that matches the selection criteria.
        /// </summary>
        /// <param name="id">The <see cref="Gender"/> identifier.</param>
        /// <param name="requestOptions">The optional <see cref="WebApiRequestOptions"/>.</param>
        /// <returns>A <see cref="WebApiAgentResult"/>.</returns>
        Task<WebApiAgentResult<Gender>> GetAsync(Guid id, WebApiRequestOptions? requestOptions = null);

        /// <summary>
        /// Creates the <see cref="Gender"/> object.
        /// </summary>
        /// <param name="value">The <see cref="Gender"/> object.</param>
        /// <param name="requestOptions">The optional <see cref="WebApiRequestOptions"/>.</param>
        /// <returns>A <see cref="WebApiAgentResult"/>.</returns>
        Task<WebApiAgentResult<Gender>> CreateAsync(Gender value, WebApiRequestOptions? requestOptions = null);

        /// <summary>
        /// Updates the <see cref="Gender"/> object.
        /// </summary>
        /// <param name="value">The <see cref="Gender"/> object.</param>
        /// <param name="id">The <see cref="Gender"/> identifier.</param>
        /// <param name="requestOptions">The optional <see cref="WebApiRequestOptions"/>.</param>
        /// <returns>A <see cref="WebApiAgentResult"/>.</returns>
        Task<WebApiAgentResult<Gender>> UpdateAsync(Gender value, Guid id, WebApiRequestOptions? requestOptions = null);
    }

    /// <summary>
    /// Provides the Gender Web API service agent.
    /// </summary>
    public partial class GenderServiceAgent : WebApiServiceAgentBase<GenderServiceAgent>, IGenderServiceAgent
    {
        /// <summary>
        /// Static constructor.
        /// </summary>
        static GenderServiceAgent()
        {
            Register(() =>
            {
                var rd = WebApiServiceAgentManager.Get<GenderServiceAgent>();
                return rd == null ? null : new GenderServiceAgent(rd.Client, rd.BeforeRequest!);
            }, false);
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="GenderServiceAgent"/> class with a <paramref name="httpClient"/>.
        /// </summary>
        /// <param name="httpClient">The <see cref="HttpClient"/>.</param>
        /// <param name="beforeRequest">The <see cref="Action{HttpRequestMessage}"/> to invoke before the <see cref="HttpRequestMessage">Http Request</see> is made (see <see cref="WebApiServiceAgentBase.BeforeRequest"/>).</param>
        public GenderServiceAgent(HttpClient? httpClient = null, Action<HttpRequestMessage>? beforeRequest = null) : base(httpClient, beforeRequest) { }

        /// <summary>
        /// Gets the <see cref="Gender"/> object that matches the selection criteria.
        /// </summary>
        /// <param name="id">The <see cref="Gender"/> identifier.</param>
        /// <param name="requestOptions">The optional <see cref="WebApiRequestOptions"/>.</param>
        /// <returns>A <see cref="WebApiAgentResult"/>.</returns>
        public Task<WebApiAgentResult<Gender>> GetAsync(Guid id, WebApiRequestOptions? requestOptions = null)
        {
            return base.GetAsync<Gender>("api/v1/demo/ref/genders/{id}", requestOptions: requestOptions,
                args: new WebApiArg[] { new WebApiArg<Guid>("id", id) });
        }

        /// <summary>
        /// Creates the <see cref="Gender"/> object.
        /// </summary>
        /// <param name="value">The <see cref="Gender"/> object.</param>
        /// <param name="requestOptions">The optional <see cref="WebApiRequestOptions"/>.</param>
        /// <returns>A <see cref="WebApiAgentResult"/>.</returns>
        public Task<WebApiAgentResult<Gender>> CreateAsync(Gender value, WebApiRequestOptions? requestOptions = null)
        {
            if (value == null)
                throw new ArgumentNullException("value");

            return base.PostAsync<Gender>("api/v1/demo/ref/genders", value, requestOptions: requestOptions,
                args: new WebApiArg[] { });
        }

        /// <summary>
        /// Updates the <see cref="Gender"/> object.
        /// </summary>
        /// <param name="value">The <see cref="Gender"/> object.</param>
        /// <param name="id">The <see cref="Gender"/> identifier.</param>
        /// <param name="requestOptions">The optional <see cref="WebApiRequestOptions"/>.</param>
        /// <returns>A <see cref="WebApiAgentResult"/>.</returns>
        public Task<WebApiAgentResult<Gender>> UpdateAsync(Gender value, Guid id, WebApiRequestOptions? requestOptions = null)
        {
            if (value == null)
                throw new ArgumentNullException("value");

            return base.PutAsync<Gender>("api/v1/demo/ref/genders/{id}", value, requestOptions: requestOptions,
                args: new WebApiArg[] { new WebApiArg<Guid>("id", id) });
        }
    }
}

#nullable restore