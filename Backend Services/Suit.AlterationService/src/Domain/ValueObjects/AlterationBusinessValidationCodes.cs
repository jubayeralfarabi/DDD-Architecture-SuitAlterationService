namespace Suit.AlterationService.Domain.Aggregates
{
    public class AlterationBusinessValidationCodes
    {
        public const int PropertyIsNullEmptyNotUnique = 00100001;
        public const int PropertyRequiresPositiveOrZeroValue = 00100002;
        public const int PropertyRequiresPositiveAndNonZeroValue = 00100003;
        public const int ArrayMustHaveAnElement = 00100004;
        public const int EntityAlreadyExists = 00100006;
        public const int EntityDoesNotExists = 00100007;
        public const int AccessToEntityIsDenied = 00100008;
        public const int ArrayElementsRequireProperValues = 00100009;
        public const int PropertyIsNullEmpty = 001000010;

        public const int InvalidAlterationValue = 00100011;
        public const int InvalidAlterationType = 00100012;
        public const int AlreadyPaid = 00100013;
        public const int PaymentRequired = 00100014;
    }
}
