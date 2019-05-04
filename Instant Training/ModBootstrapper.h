#pragma once

#include "Wrappers/CommandWrapperImpl.h"
#include "Wrappers/EventWrapperImpl.h"
#include "GameEndedEventHook.h"
#include "LaunchMapEventHandler.h"

class ModBootstrapper
{
public:
	explicit ModBootstrapper(const std::shared_ptr<GameWrapper>& gameWrapper);

private:
	const CommandWrapperImpl commandWrapper;
	const EventWrapperImpl eventWrapper;

	const GameEndedEventHook gameEndedEventHook;
	const LaunchMapEventHandler launchMapEventHandler;
};