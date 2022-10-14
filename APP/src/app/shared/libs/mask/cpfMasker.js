import masker from './masker'

export default function (value) {
  return masker(value, '###.###.###-##')
}
