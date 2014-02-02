namespace Ribbonizer.Results
{
    using System;

    public class AnonymousResult : AbstractResult, IAnonymousResult
    {
        private readonly Action executionAction;

        public AnonymousResult(Action executionAction)
        {
            this.executionAction = executionAction;
        }

        protected override void Execute()
        {
            this.executionAction();
        }
    }
}