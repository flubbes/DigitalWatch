namespace DigitalWatch.Behaviors
{
    public class SingletonClockBehavior
    {
        private static object _singletonContainer;

        public SingletonClockBehavior()
        {
            if (_singletonContainer == null)
            {
                _singletonContainer = this;
            }
        }

        public object SingletonContainer
        {
            get { return _singletonContainer; }
        }
    }
}