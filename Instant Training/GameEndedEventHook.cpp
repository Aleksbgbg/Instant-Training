#include "GameEndedEventHook.h"

GameEndedEventHook::GameEndedEventHook(const EventWrapper& eventWrapper)
	:
	eventWrapper{ eventWrapper },
	eventFunction{ nullptr }
{
}

void GameEndedEventHook::Hook(const std::function<void()>& function)
{
	eventFunction = &function;
	eventWrapper.HookEvent(GameEndedHookString, std::bind(&GameEndedEventHook::EventHandler, this));
}

void GameEndedEventHook::EventHandler() const
{
	(*eventFunction)();
}