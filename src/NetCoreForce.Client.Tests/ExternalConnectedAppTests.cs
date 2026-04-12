using NetCoreForce.FunctionalTests;
using NetCoreForce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NetCoreForce.Client.Tests
{
    public class ExternalConnectedAppTests : IClassFixture<ForceClientFixture>
    {
        ForceClientFixture forceClientFixture;

        public ExternalConnectedAppTests(ForceClientFixture fixture)
        {
            this.forceClientFixture = fixture;
        }

        [Fact]
        public async Task InsertTest()
        {
            ForceClient client = await forceClientFixture.GetForceRefreshTokenClient();


        }
    }
}
