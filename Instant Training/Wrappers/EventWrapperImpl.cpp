#include "EventWrapperImpl.h"

#include <utility>

EventWrapperImpl::EventWrapperImpl(std::shared_ptr<GameWrapper> gameWrapper)
	:
	gameWrapper{ std::move(gameWrapper) }
{
}

void EventWrapperImpl::HookEvent(const std::string& eventName, const std::function<void(std::string)>& callback) const
{
	gameWrapper->HookEvent(eventName, callback);
}

void EventWrapperImpl::UnhookEvent(const std::string& eventName) const
{
	gameWrapper->UnhookEvent(eventName);
}