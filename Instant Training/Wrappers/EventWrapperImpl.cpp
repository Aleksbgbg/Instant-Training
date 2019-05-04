#include "EventWrapperImpl.h"

EventWrapperImpl::EventWrapperImpl(const std::shared_ptr<GameWrapper> gameWrapper)
	:
	gameWrapper{ gameWrapper }
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