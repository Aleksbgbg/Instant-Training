#include "EventHandler.h"

EventHandler::EventHandler(const EventHook& eventHook)
	:
	eventHook{ eventHook }
{
	eventHook.Hook(std::bind(&EventHandler::OnEvent, this));
}