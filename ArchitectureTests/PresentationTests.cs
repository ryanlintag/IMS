using FluentAssertions;
using NetArchTest.Rules;
using Presentation;
using Xunit;

namespace ArchitectureTests
{
    public class PresentationTests
    {
        [Fact]
        public void All_Presentation_Modules_should_inherit_from_ApiModule()
        {
            //Arrange
            var presentationAssembly = typeof(Presentation.AssemblyReference).Assembly;
            var moduleNamespace = "Presentation.Modules";
            var apiModuleName = typeof(ApiModule);

            //Act
            var result = Types.InAssembly(presentationAssembly)
                            .That()
                            .ResideInNamespaceStartingWith(moduleNamespace)
                            .Should()
                            .Inherit(apiModuleName)
                            .GetResult();

            //Assert
            result.IsSuccessful.Should().BeTrue();
        }
        [Fact]
        public void ApiModule_should_inherit_from_IModule()
        {
            //Arrange
            var presentationAssembly = typeof(Presentation.AssemblyReference).Assembly;
            var moduleNamespace = "Presentation";
            var IModuleInterfaceName = typeof(IModule);

            //Act
            var result = Types.InAssembly(presentationAssembly)
                            .That()
                            .ResideInNamespaceStartingWith(moduleNamespace)
                            .And()
                            .HaveNameMatching("ApiModule")
                            .Should()
                            .ImplementInterface(IModuleInterfaceName)
                            .GetResult();

            //Assert
            result.IsSuccessful.Should().BeTrue();
        }
        [Fact]
        public void All_Presentation_Modules_that_inherit_from_IModule_should_be_sealed_and_public()
        {
            //Arrange
            var presentationAssembly = typeof(Presentation.AssemblyReference).Assembly;
            var moduleNamespace = "Presentation.Modules";

            //Act
            var result = Types.InAssembly(presentationAssembly)
                            .That()
                            .ResideInNamespaceStartingWith(moduleNamespace)
                            .Should()
                            .BeSealed()
                            .And()
                            .BePublic()
                            .GetResult();

            //Assert
            result.IsSuccessful.Should().BeTrue();
        }
        [Fact]
        public void All_Presentation_Modules_that_inherit_from_IModule_should_end_in_Module_name()
        {
            //Arrange
            var presentationAssembly = typeof(Presentation.AssemblyReference).Assembly;
            var moduleNamespace = "Presentation.Modules";
            var IModuleInterfaceName = typeof(IModule);
            var modulePostName = "Module";

            //Act
            var result = Types.InAssembly(presentationAssembly)
                            .That()
                            .ResideInNamespaceStartingWith(moduleNamespace)
                            .And()
                            .ImplementInterface(IModuleInterfaceName)
                            .Should()
                            .HaveNameEndingWith(modulePostName)
                            .GetResult();

            //Assert
            result.IsSuccessful.Should().BeTrue();
        }
    }
}
