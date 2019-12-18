using System;
using FluentAssertions;
using Oeuvre.Domain.Entities;
using Oeuvre.Functions;
using TechTalk.SpecFlow;

namespace Oeuvre.Services.Tests {
    [Binding]
    public class CreateDocumentSteps {
        private readonly InMemoryEventStore _eventStore = new InMemoryEventStore();
        private CreateDocumentFunction _createDocument;

        [Given(@"user creates a new document")]
        public void GivenUserCreatesANewDocument() {
            _createDocument = new CreateDocumentFunction();
        }

        [Given(@"changes the title to ""(.*)""")]
        public void GivenChangesTheTitleTo(string title) {
            _createDocument.Title = title;
        }
        
        [Given(@"changes the content to ""(.*)""")]
        public void GivenChangesTheContentTo(string text) {
            _createDocument.Content = new TextContent(text);
        }

        [When(@"presses the save button")]
        public void WhenPressesTheSaveButton() {
            var invoker = new FunctionInvoker(new DelegateServiceProvider(TypeResolver));
            invoker.InvokeAsync(_createDocument);
        }

        [Then(@"a new document should be stored")]
        public void ThenANewDocumentShouldBeStored() {
            var doc = Document.LoadFrom(_eventStore.Events);
            
            doc.Should().BeEquivalentTo(new {
                _createDocument.Title
            });
            
            doc.CreatedAt.Should().BeCloseTo(DateTimeOffset.UtcNow, 100);
        }

        private object TypeResolver(Type type) {
            if (typeof(IFunctionHandler<CreateDocumentFunction>).IsAssignableFrom(type)) {
                return new CreateDocumentFunctionHandler(_eventStore);
            }
            throw new NotSupportedException();
        }
    }
}