#include "../Instant Training/Wrappers/CommandWrapper.h"
#include "../Instant Training/EventHook.h"
#include "../Instant Training/LaunchMapEventHandler.h"

#include "test.h"

SCENARIO("raise event hook", "[LaunchMapEventHandler]")
{
	GIVEN("a LaunchMapEventHandler with a CommandWrapper and EventHook")
	{
		Mock<CommandWrapper> commandWrapperMock;
		Fake(Method(commandWrapperMock, ExecuteCommand).Using("open Park_P?Game=TAGame.GameInfo_Tutorial_TA?FreePlay"));

		std::function<void()> hookedFunction;

		Mock<EventHook> eventHookMock;
		When(Method(eventHookMock, Hook)).Do([&hookedFunction](const std::function<void()>& function)
		{
			hookedFunction = function;
		});

		LaunchMapEventHandler launchMapEventHandler{ commandWrapperMock.get(), eventHookMock.get() };

		WHEN("the hooked function is invoked")
		{
			hookedFunction();

			THEN("the launch map command is executed")
			{
				Verify(Method(commandWrapperMock, ExecuteCommand));
			}
		}
	}
}