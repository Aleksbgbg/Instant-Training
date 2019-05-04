#pragma once

#include "EventHandler.h"
#include "Wrappers/CommandWrapper.h"

class LaunchMapEventHandler : EventHandler
{
public:
	LaunchMapEventHandler(const CommandWrapper& commandWrapper, const EventHook& eventHook);

protected:
	void OnEvent() const override;

private:
	static constexpr const char* LaunchMapCommand = "open Park_P?Game=TAGame.GameInfo_Tutorial_TA?FreePlay";

private:
	const CommandWrapper& commandWrapper;
};