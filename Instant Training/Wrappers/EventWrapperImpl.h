#pragma once

#include <memory>

#include <bakkesmod/wrappers/gamewrapper.h>

#include "Wrappers/EventWrapper.h"

class EventWrapperImpl : EventWrapper
{
public:
	explicit EventWrapperImpl(const std::shared_ptr<GameWrapper> gameWrapper);

public:
	void HookEvent(const std::string& eventName, const std::function<void(std::string)>& callback) const override;

private:
	const std::shared_ptr<GameWrapper> gameWrapper;
};