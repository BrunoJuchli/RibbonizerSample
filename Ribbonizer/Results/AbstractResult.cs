namespace Ribbonizer.Results
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    using Caliburn.Micro;

    public abstract class AbstractResult : IResult
    {
        public event EventHandler<ResultCompletionEventArgs> Completed;

        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Exception is passed to the completed event which is correctly handled by caliburn.")]
        public void Execute(ActionExecutionContext context)
        {
            try
            {
                this.Execute();
                this.OnCompleted();
            }
            catch (Exception ex)
            {
                this.OnCompleted(ex);
            }
        }

        protected abstract void Execute();

        protected void OnCompleted()
        {
            this.OnCompleted(null);
        }

        protected virtual void OnCompleted(Exception exception)
        {
            this.Completed.SafeInvoke(this, new ResultCompletionEventArgs { Error = exception });
        }
    }
}