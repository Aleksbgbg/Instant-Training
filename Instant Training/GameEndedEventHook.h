#pragma once

#include "EventHook.h"
#include "Wrappers/EventWrapper.h"

class GameEndedEventHook : EventHook
{
public:
	explicit GameEndedEventHook(const EventWrapper& eventWrapper);

public:
	void Hook(const std::function<void()>& function) const override;
	void Unhook() const override;

private:
	static constexpr const char* GameEndedHookString = "Function TAGame.GameEvent_Soccar_TA.EventMatchEnded";

private:
	const EventWrapper& eventWrapper;
};