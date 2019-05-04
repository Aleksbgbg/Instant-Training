#include "test.h"

#include "../Instant Training/GameEndedEventHook.h"

static void FunctionStub()
{
}

SCENARIO("GameEndedEventHook can be hooked and unhooked", "[GameEndedEventHook]")
{
	GIVEN("A GameEndedEventHook with an EventWrapper")
	{
		static constexpr const char* GameEndedHookString = "Function TAGame.GameEvent_Soccar_TA.EventMatchEnded";

		Mock<EventWrapper> eventWrapperMock;
		Fake(Method(eventWrapperMock, HookEvent).Using(GameEndedHookString, Any<std::function<void(std::string)>>()));
		Fake(Method(eventWrapperMock, UnhookEvent).Using(GameEndedHookString));

		EventWrapper& eventWrapper = eventWrapperMock.get();

		GameEndedEventHook gameEndedEventHook{ eventWrapper };

		WHEN("Hook is called")
		{
			gameEndedEventHook.Hook(FunctionStub);

			THEN("HookEvent is called on EventWrapper")
			{
				Verify(Method(eventWrapperMock, HookEvent));
			}
		}

		WHEN("Unhook is called")
		{
			gameEndedEventHook.Unhook();

			THEN("UnhookEvent is called on EventWrapper")
			{
				Verify(Method(eventWrapperMock, UnhookEvent));
			}
		}
	}
}