#include "CommandWrapperImpl.h"

CommandWrapperImpl::CommandWrapperImpl(const std::shared_ptr<GameWrapper> gameWrapper)
	:
	gameWrapper{ gameWrapper }
{
}

void CommandWrapperImpl::ExecuteCommand(const std::string& command) const
{
	gameWrapper->ExecuteUnrealCommand(command);
}