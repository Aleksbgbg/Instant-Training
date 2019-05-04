#include "LaunchMapEventHandler.h"

LaunchMapEventHandler::LaunchMapEventHandler(const CommandWrapper& commandWrapper, const EventHook& eventHook)
	:
	EventHandler{ eventHook },
	commandWrapper{ commandWrapper }
{
}

void LaunchMapEventHandler::OnEvent() const
{
	commandWrapper.ExecuteCommand(LaunchMapCommand);
}