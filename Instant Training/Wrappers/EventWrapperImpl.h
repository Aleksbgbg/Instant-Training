#pragma once

#include <memory>

#include <bakkesmod/wrappers/gamewrapper.h>

#include "EventWrapper.h"

class EventWrapperImpl : public EventWrapper
{
public:
	explicit EventWrapperImpl(std::shared_ptr<GameWrapper> gameWrapper);

public:
	void HookEvent(const std::string& eventName, const std::function<void(std::string)>& callback) const override;
	void UnhookEvent(const std::string& eventName) const override;

private:
	const std::shared_ptr<GameWrapper> gameWrapper;
};