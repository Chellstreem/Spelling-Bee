﻿namespace Cameras
{
    public class MainCameraBehaviour : IEventSubscriber<OnCountdownStateEnter>, IEventSubscriber<OnMovingStateEnter>,
        IEventSubscriber<OnVictory>, IEventSubscriber<OnLossStateEnter>
    {
        private readonly EventManager eventManager;
        private readonly ISingleCameraMover cameraMover;        

        public MainCameraBehaviour(EventManager eventManager, ISingleCameraMover cameraMover)
        {
            this.eventManager = eventManager;
            this.cameraMover = cameraMover;            

            SubscribeToEvents();
        }

        public void OnEvent(OnCountdownStateEnter eventData)
        {
            cameraMover.ChangeState(CameraStateType.Start);
        }

        public void OnEvent(OnMovingStateEnter eventData)
        {
            cameraMover.ChangeStateSmoothly(CameraStateType.Move, 1f);
        }

        public void OnEvent(OnVictory eventData)
        {
            cameraMover.ChangeStateSmoothly(CameraStateType.Victory, 1.5f);
        }

        public void OnEvent(OnLossStateEnter eventData)
        {
            cameraMover.ChangeStateSmoothly(CameraStateType.Loss, 1.5f);
        }

        private void SubscribeToEvents()
        {
            eventManager.Subscribe<OnCountdownStateEnter>(this);
            eventManager.Subscribe<OnMovingStateEnter>(this);
            eventManager.Subscribe<OnVictory>(this);
            eventManager.Subscribe<OnLossStateEnter>(this);
        }

        private void UnsubscribeFromEvents()
        {
            eventManager.Unsubscribe<OnCountdownStateEnter>(this);
            eventManager.Unsubscribe<OnMovingStateEnter>(this);
            eventManager.Unsubscribe<OnVictory>(this);
            eventManager.Unsubscribe<OnLossStateEnter>(this);
        }
    }
}
