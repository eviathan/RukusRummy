export function castStringToEnum(enumType: any, value: string) {
    if (value in enumType) {
        return enumType[value as keyof typeof enumType];
    } else {
        throw new Error(`Invalid value: ${value}`);
    }
}