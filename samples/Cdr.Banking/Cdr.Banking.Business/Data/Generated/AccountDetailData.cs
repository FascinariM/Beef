/*
 * This file is automatically generated; any changes will be lost. 
 */

#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Beef;
using Beef.Business;
using Microsoft.Azure.Cosmos;
using Beef.Data.Cosmos;
using Beef.Entities;
using Beef.Mapper;
using Beef.Mapper.Converters;
using Cdr.Banking.Common.Entities;
using RefDataNamespace = Cdr.Banking.Common.Entities;

namespace Cdr.Banking.Business.Data
{
    /// <summary>
    /// Provides the <see cref="Account"/> Detail data access.
    /// </summary>
    public partial class AccountDetailData
    {

        /// <summary>
        /// Provides the <see cref="AccountDetail"/> entity and Cosmos <see cref="Model.Account"/> property mapping.
        /// </summary>
        public partial class CosmosMapper : CosmosDbMapper<AccountDetail, Model.Account, CosmosMapper>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="CosmosMapper"/> class.
            /// </summary>
            public CosmosMapper()
            {
                InheritPropertiesFrom(AccountData.CosmosMapper.Default);
                Property(s => s.Bsb, d => d.Bsb);
                Property(s => s.AccountNumber, d => d.AccountNumber);
                Property(s => s.BundleName, d => d.BundleName);
                Property(s => s.SpecificAccountUTypeSid, d => d.SpecificAccountUType);
                Property(s => s.TermDeposit, d => d.TermDeposit);
                Property(s => s.CreditCard, d => d.CreditCard);
                AddStandardProperties();
                CosmosMapperCtor();
            }
            
            /// <summary>
            /// Enables the <see cref="CosmosMapper"/> constructor to be extended.
            /// </summary>
            partial void CosmosMapperCtor();
        }
    }
}

#nullable restore