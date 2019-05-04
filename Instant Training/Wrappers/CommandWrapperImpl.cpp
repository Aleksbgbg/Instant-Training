#include "CommandWrapperImpl.h"

#include <utility>

CommandWrapperImpl::CommandWrapperImpl(std::shared_ptr<GameWrapper> gameWrapper)
	:
	gameWrapper{ std::move(gameWrapper) }
{
}

void CommandWrapperImpl::ExecuteCommand(const std::string& command) const
{
	gameWrapper->ExecuteUnrealCommand(command);
}