#include "test.h"

#include "../Instant Training/GameEndedEventHook.h"

void FunctionStub()
{
}

TEST_CASE("Hook calls EventWrapper HookEvent")
{
	Mock<EventWrapper> eventWrapperMock;
	Fake(Method(eventWrapperMock, HookEvent));

	EventWrapper& eventWrapper = eventWrapperMock.get();

	GameEndedEventHook gameEndedHook{ eventWrapper };
	gameEndedHook.Hook(FunctionStub);

	Verify(Method(eventWrapperMock, HookEvent));
}