#include "ModBootstrapper.h"

ModBootstrapper::ModBootstrapper(const std::shared_ptr<GameWrapper>& gameWrapper)
	:
	commandWrapper{ gameWrapper },
	eventWrapper{ gameWrapper },
	gameEndedEventHook{ eventWrapper },
	launchMapEventHandler{ commandWrapper, gameEndedEventHook }
{
}