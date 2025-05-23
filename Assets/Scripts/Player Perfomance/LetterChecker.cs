﻿using UnityEngine;

namespace PlayerPerfomance
{
    public class LetterChecker : IEventSubscriber<OnLetterCollision>
    {
        private readonly EventManager eventManager;
        private readonly IHiddenIndexGetter indexGetter;

        public LetterChecker(EventManager eventManager, IHiddenIndexGetter indexGetter)
        {
            this.eventManager = eventManager;
            this.indexGetter = indexGetter;

            this.eventManager.Subscribe<OnLetterCollision>(this);
        }

        public void OnEvent(OnLetterCollision eventData)
        {
            CheckLetter(eventData.Value, eventData.Position);
        }

        private void CheckLetter(string letter, Vector3 position)
        {
            int index = indexGetter.GetHiddenIndex(letter);
            if (index != -1)
            {
                eventManager.Publish(new OnLetterChecked(letter, true, position));
            }
            else
            {
                eventManager.Publish(new OnLetterChecked(letter, false, position));
            }
        }
    }
}
