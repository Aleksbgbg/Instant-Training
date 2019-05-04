#include "GameEndedEventHook.h"

GameEndedEventHook::GameEndedEventHook(const EventWrapper& eventWrapper)
	:
	eventWrapper{ eventWrapper }
{
}

void GameEndedEventHook::Hook(const std::function<void()>& function) const
{
	eventWrapper.HookEvent(GameEndedHookString, std::bind(function));
}

void GameEndedEventHook::Unhook() const
{
	eventWrapper.UnhookEvent(GameEndedHookString);
}