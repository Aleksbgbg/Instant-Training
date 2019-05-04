#pragma once

#include "EventHook.h"

class EventHandler
{
public:
	explicit EventHandler(const EventHook& eventHook);

	virtual ~EventHandler() = default;

protected:
	virtual void OnEvent() const = 0;

private:
	const EventHook& eventHook;
};