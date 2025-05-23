using UnityEngine;

namespace Sounds
{
    public class MusicHandler : IEventSubscriber<OnMovingStateEnter>, IEventSubscriber<OnMovingStateExit>,
        IEventSubscriber<OnVictory>
    {
        private readonly EventManager eventManager;
        private readonly IMusicPlayer musicPlayer;        

        public MusicHandler(EventManager eventManager, IMusicPlayer musicPlayer)
        {
            this.eventManager = eventManager;
            this.musicPlayer = musicPlayer;

            SubscribeToEvents();
        }

        public void OnEvent(OnMovingStateEnter eventData)
        {
            musicPlayer.PlaySound(SoundType.GamePlayMusic);
        }

        public void OnEvent(OnMovingStateExit eventData)
        {
            musicPlayer.StopSound(SoundType.GamePlayMusic);
        }

        public void OnEvent(OnVictory eventData)
        {
            musicPlayer.PlaySound(SoundType.Victory);
        }

        private void SubscribeToEvents()
        {
            eventManager.Subscribe<OnMovingStateEnter>(this);
            eventManager.Subscribe<OnMovingStateExit>(this);
            eventManager.Subscribe<OnVictory>(this);
        }        
    }
}
